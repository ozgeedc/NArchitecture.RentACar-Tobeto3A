using Core.Persistence.Paging.Core.Persistence.Paging;

namespace Core.Persistence.Paging;

public class Paginate<TSource, TResult> : IPaginate<TResult>
{
    public Paginate(IEnumerable<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter,
                    int index, int size, int from)
    {
        var enumerable = source as TSource[] ?? source.ToArray();

        if (from > index) throw new ArgumentException($"From: {from} > Index: {index}, must From <= Index");

        if (source is IQueryable<TSource> queryable)
        {
            Index = index;
            Size = size;
            From = from;
            Count = queryable.Count();
            Pages = (int)Math.Ceiling(Count / (double)Size);

            var items = queryable.Skip((Index - From) * Size).Take(Size).ToArray();

            Items = new List<TResult>(converter(items));
        }
        else
        {
            Index = index;
            Size = size;
            From = from;
            Count = enumerable.Count();
            Pages = (int)Math.Ceiling(Count / (double)Size);

            var items = enumerable.Skip((Index - From) * Size).Take(Size).ToArray();

            Items = new List<TResult>(converter(items));
        }
    }
    public Paginate(IPaginate<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
    {
        Index = source.Index;
        Size = source.Size;
        From = source.From;
        Count = source.Count;
        Pages = source.Pages;

        Items = new List<TResult>(converter(source.Items));
    }

    public int Index { get; }

    public int Size { get; }

    public int Count { get; }

    public int Pages { get; }

    public int From { get; }

    public IList<TResult> Items { get; }

    public bool HasPrevious => Index - From > 0;

    public bool HasNext => Index - From + 1 < Pages;
}

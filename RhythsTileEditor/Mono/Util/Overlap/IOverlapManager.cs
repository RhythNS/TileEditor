using Mono.Util.Datatypes;
using System.Collections.Generic;

namespace Mono.Util.Overlap
{
    public interface IOverlapManager<T> where T : IOverlapable
    {
        List<T> GetAllOverlaps(List<T> list, Box2D toCheck);

        List<T> GetAllOverlaps(List<T> list, T toCheck);

        List<T> GetAllOverlaps(T toCheck);

        List<T> GetAllOverlaps(Box2D toCheck);

        List<T> GetListWhenLast();

        void Add(T toAdd);

        void AddAll(List<T> toAdd);

        void AddAll(params T[] toAdd);

        void Remove(T toRemove);

        bool IsLast();
    }
}
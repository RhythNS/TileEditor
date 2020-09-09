using Mono.Util.Datatypes;

namespace Mono.Util.Overlap
{
    public abstract class Overlapable : IOverlapable
    {
        public abstract Box2D GetBox();

        public bool Overlaps(IOverlapable other) => GetBox().Intersecting(other.GetBox());

        public bool Overlaps(Box2D other) => GetBox().Intersecting(other);
        
    }
}
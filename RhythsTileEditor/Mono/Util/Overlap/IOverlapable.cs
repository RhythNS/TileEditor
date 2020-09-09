using Mono.Util.Datatypes;

namespace Mono.Util.Overlap
{
    public interface IOverlapable
    {
        Box2D GetBox();

        bool Overlaps(IOverlapable other);

        bool Overlaps(Box2D other);
    }
}

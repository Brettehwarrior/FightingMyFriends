using Fighter.Common.Collisions;

namespace Fighter.Common.Collisions
{
    public interface IHittable
    {
        void Hit(HurtboxData hurtboxData, bool flip);
    }
}
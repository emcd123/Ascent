

using Ascent.Entities;

namespace Ascent
{
    public interface ICommandItem
    {
        void Execute(Actor actor, Item item);
    }
}

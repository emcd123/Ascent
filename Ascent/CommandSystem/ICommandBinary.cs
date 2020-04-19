

using Ascent.Entities;

namespace Ascent
{
    public interface ICommandBinary
    {
        void Execute(Actor primary_actor, Actor secondary_actor);
    }
}

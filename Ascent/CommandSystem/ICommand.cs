

using Ascent.Entities;

namespace Ascent
{
    public interface ICommand
    {
        void Execute(Actor primary_actor);
    }
}

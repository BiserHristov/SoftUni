using System.Collections.Generic;

namespace P07.MilitaryElite.Interfaces
{
    public interface ILieutenantGeneral : IPrivate
    {
        public IReadOnlyCollection<IPrivate> Privates { get; }
        void AddPrivate(IPrivate @private);
    }
}

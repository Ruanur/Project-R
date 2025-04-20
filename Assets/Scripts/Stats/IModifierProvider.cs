using System.Collections.Generic;

namespace RPG.Stats
{
    public interface IModifierProvider
    {
        //IEnumerator VS IEnumerable, foreach?
        IEnumerable<float> GetAdditiveModifier(Stat stat);
    }
}
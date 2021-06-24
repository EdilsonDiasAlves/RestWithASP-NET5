using System.Collections.Generic;

namespace RestWithASP_NET5.Data.Converter
{
    // Work as a parser from an object to another being O (Origin object) and D (Destiny object)
    public interface IConverter<O,D>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}

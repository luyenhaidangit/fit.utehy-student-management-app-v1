using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interface
{
    public interface IBUS<A, B>
    {
        List<A> GetData();

        void Add(A Object);

        void Edit(A objectOld, B objectNew);

        void Delete(A objectOld);

        void Save(List<A> listObject);

    }
}

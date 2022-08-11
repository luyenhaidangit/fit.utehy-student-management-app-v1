using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO.Interface
{
    public interface IDAO<A, B>
    {
        List<A> GetData();

        void Add(A Object);

        void Edit(A objectOld, B objectNew);

        void Delete(A objectOld);

        void Save(List<A> listObject);

    }
}

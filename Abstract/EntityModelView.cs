using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.Abstract
{
    public class EntityModelView<T> : BaseModelView
    {
        protected T _model;

        public EntityModelView(T model)
        {
            this._model = model;
            _db = new DataBase.AdmissionsCommitteeDBContainer();
        }

        public override void Add(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Redact(object obj)
        {
            throw new NotImplementedException();
        }
    }
}

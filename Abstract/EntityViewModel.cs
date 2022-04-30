using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.Abstract
{
    public class EntityViewModel<T> : BaseViewModel
    {
        protected T _model;

        public EntityViewModel(T model)
        {
            this._model = model;
        }

    }
}

using Project.Repositories;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Business
{
    public class BaseBusiness<TViewModel, TRepository> : IConcurrencyChecker where TRepository : BaseRepository, new()
    {
        private TRepository repository;
        public BaseBusiness()
        {
            repository = new TRepository();
        }
        public virtual void Save()
        {

        }
        public bool IsValid(IConcurrency model)
        {
            return repository.IsNotConcurrent(model);
        }
    }
}

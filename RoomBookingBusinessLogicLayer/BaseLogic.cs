using RoomBookingDataAccessLayer;
using RoomBookingPocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomBookingBusinessLogicLayer
{
    public class BaseLogic<TPoco>
    {
        private readonly IDataRepository<TPoco> _repository;

        public BaseLogic(IDataRepository<TPoco> repository)
        {
            _repository = repository;
        }

        public virtual void add(params TPoco[] pocos)
        {
            _repository.Add(pocos);
        }

        public virtual void Update(params TPoco[] pocos)
        {
            _repository.Update(pocos);
        }

        public virtual void Remove(params TPoco[] pocos)
        {
            _repository.Remove(pocos);
        }

        public virtual List<TPoco> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        protected virtual void Verify(TPoco[] pocos)
        {
            return;
        }
    }
}

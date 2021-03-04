﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class CarManager:ICarService
    {
        //business dataacces i kullandığı için da bağımlıdır
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

       
        public IResult Add(Car car)
        {
            {
                if (car.CarName.Length<2)
                {
                    return new ErrorResult(Messages.CarNameInvalid);
                }
                _carDal.Add(car);

                return new SuccessResult(Messages.CarAdded );
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==15)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id) 
        {
            //expression = predicate
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == id));
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>>GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }
}

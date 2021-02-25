using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageCount());
            if (result != null)
            {
                return result;
            }

            string createPath = ImagePath(carImage.CarId);
            File.Copy(carImage.ImagePath, createPath);
            carImage.ImagePath = createPath;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var imageData = _carImageDal.Get(p => p.Id == carImage.Id);
            File.Delete(imageData.ImagePath);
            _carImageDal.Delete(imageData);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(CarImage carImage)
        {
            string createPath = ImagePath(carImage.CarId);
            File.Copy(carImage.ImagePath, createPath);
            File.Delete(carImage.ImagePath);
            carImage.ImagePath = createPath;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarId(carId));
            if (result != null)
            {
                return (IDataResult<List<CarImage>>)result;
            }

            var getAllbyCarIdResult = _carImageDal.GetAll(p => p.CarId == carId);
            if (getAllbyCarIdResult.Count == 0)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage> { new CarImage { ImagePath = FilePath.ImageDefaultPath } });
            }

            return new SuccessDataResult<List<CarImage>>(getAllbyCarIdResult);
        }

        private string ImagePath(int carId)
        {
            return AppDomain.CurrentDomain.BaseDirectory + "Images\\" + carId + "_" + DateTime.Now.ToShortDateString() + ".jpg";
        }

        private IResult CheckCarImageCount()
        {
            if (_carImageDal.GetAll().Count > 4)
            {
                return new ErrorResult(Messages.ImageAddingLimit);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarId(int carId)
        {
            if (!_carService.GetById(carId).Success)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.GetErrorCarDetails);
            }
            return new SuccessDataResult<List<CarImage>>();
        }
    }
}

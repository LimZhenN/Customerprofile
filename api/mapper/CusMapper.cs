using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.mapper
{
    public static class CusMapper
    {
        public static CusDtos ToCusDto(this CusInfo cusModel)
        {
            return new CusDtos
            {
                Id =cusModel.Id,
                FirstName = cusModel.FirstName,
                LastName = cusModel.LastName,
                email = cusModel.email,
                PhoneNo = cusModel.PhoneNo
            };
        }
        public static CusInfo TocusinfoFromCreateDto(this CreateCusinfoRequestDto cusDto)
        {
            return new CusInfo
            {
                FirstName = cusDto.FirstName,
                LastName = cusDto.LastName,
                email = cusDto.email,
                PhoneNo = cusDto.PhoneNo
            };
        }
    }
}
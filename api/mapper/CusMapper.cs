using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.mapper
{
    // This static class provides mapping methods between CusInfo model and DTOs
    public static class CusMapper
    {
        // Converts a CusInfo model to a CusDtos (Data Transfer Object)
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
        // Converts a CreateCusinfoRequestDto to a CusInfo model
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
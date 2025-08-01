﻿using Mapster;
using OnlinePharmacy.Application.Common.DTOs;
using OnlinePharmacy.Application.Common.DTOs.User;
using OnlinePharmacy.Domain.Entities;

namespace OnlinePharmacy.Application.Common.Mappers
{
    public static class MapsterConfig
    {
        public static void Configure()
        {
            // Category Mappings
            TypeAdapterConfig<Category, CategoryDTO>.NewConfig().TwoWays()
                .Map(dest => dest.ParentName_Ar, src => src.ParentCategory.Name_Ar)
                .Map(dest => dest.ParentName_En, src => src.ParentCategory.Name_En);
            TypeAdapterConfig<Category, CreateCategoryDTO>.NewConfig().TwoWays();

            // City Mappings
            TypeAdapterConfig<City, CityDTO>.NewConfig()
                .Map(dest => dest.StateName, src => src.State.Name_En).TwoWays();
            TypeAdapterConfig<City, CreateCityDTO>.NewConfig().TwoWays();
            
            // Country Mappings
            TypeAdapterConfig<Country, CountryDTO>.NewConfig().TwoWays();
            TypeAdapterConfig<CreateCountryDTO, Country>.NewConfig().TwoWays();
            
            // Product Mappings
            TypeAdapterConfig<Product, ProductDTO>.NewConfig().TwoWays();
            TypeAdapterConfig<CreateProductDTO, Product>.NewConfig().TwoWays();
            
            // State Mappings
            TypeAdapterConfig<State, StateDTO>.NewConfig()
                .Map(dest => dest.CountryName, src => src.Country.Name_En).TwoWays();
            TypeAdapterConfig<CreateStateDTO, State>.NewConfig().TwoWays();

            // User Mappings
            TypeAdapterConfig<AccountCreateDTO, User>.NewConfig()
                .Map(dest => dest.NormalizedEmail, src => src.Email.ToUpper())
                .Map(dest => dest.UserName, src => string.Join("", src.Email.TakeWhile(e => e != '@')))
                .Map(dest => dest.NormalizedUserName, src => string.Join("", src.Email.ToUpper().TakeWhile(e => e != '@')));

            TypeAdapterConfig<CreateStaffDTO, User>.NewConfig()
                //.Map(dest => dest.NormalizedEmail, src => src.Email.ToUpper())
                .Map(dest => dest.UserName, src => string.Join("", src.Email.TakeWhile(e => e != '@')));
                //.Map(dest => dest.NormalizedUserName, src => string.Join("", src.Email.ToUpper().TakeWhile(e => e != '@')));

            TypeAdapterConfig<UserDTO, LoginResponseDTO>.NewConfig();
            //TypeAdapterConfig<CreateStateDTO, State>.NewConfig().TwoWays();

            //TypeAdapterConfig<ClientRegisterDTO, User>.NewConfig()
            //    .Map(dest => dest.NormalizedEmail, src => src.Email.ToUpper())
            //    .Map(dest => dest.UserName, src => src.Email.Split('@', StringSplitOptions.None).FirstOrDefault())
            //    .Map(dest => dest.NormalizedUserName, src => src.Email.Split('@', StringSplitOptions.None).FirstOrDefault()!.ToUpper());
            //TypeAdapterConfig<VerifyRegisterTokenDTO, User>.NewConfig()
            //    .Map(dest => dest.NormalizedEmail, src => src.Email.ToUpper())
            //    .Map(dest => dest.UserName, src => src.Email.Split('@', StringSplitOptions.None).FirstOrDefault())
            //    .Map(dest => dest.NormalizedUserName, src => src.Email.Split('@', StringSplitOptions.None).FirstOrDefault()!.ToUpper());

            //TypeAdapterConfig<UserNotification, GetUserNotificationsDTO>.NewConfig()
            //    .Map(dest => dest.NotificationId, src => src.Id)
            //    .Map(dest => dest.IsRead, src => src.IsDeleted);
            //TypeAdapterConfig<GCUProductReviewDTO, ProductReview>.NewConfig().TwoWays();
            //    TypeAdapterConfig<GetAllProductsDTOs, Product>.NewConfig().TwoWays();
            //    TypeAdapterConfig<GetOneProductDTOs, Product>.NewConfig().TwoWays();
            //    TypeAdapterConfig<CRUDProductDTOs, Product>.NewConfig()
            //        .Map(dest => dest.ProductTagMappings, src => src.Tags.Select(tagName => new ProductTagMapping { TagName = tagName }))
            //        .TwoWays();

            //    TypeAdapterConfig<ProductImageDTO, ProductImage>.NewConfig()
            //        .Map(dest => dest.ProductName, src => src.Product.Name)
            //        .TwoWays();

            //    TypeAdapterConfig<ProductTag, CRUDProductTagDTOs>.NewConfig()
            //        .Map(dest => dest.Products, src => src.ProductTagMappings.Select(ptm => ptm.Product));

            //    TypeAdapterConfig<ProductTagMapping, ProductTagMappingDTO>.NewConfig().TwoWays();
            //    TypeAdapterConfig<CRUDCouponDTO, Coupon>.NewConfig().TwoWays();
            //    TypeAdapterConfig<UpdateCouponDTO, Coupon>.NewConfig().TwoWays();
            //    TypeAdapterConfig<CreateCouponDTO, Coupon>.NewConfig().TwoWays();
            //    TypeAdapterConfig<Brand, BrandDTO>.NewConfig().TwoWays();
            //    TypeAdapterConfig<Brand, CreateBrandDTO>.NewConfig().TwoWays();
            //    TypeAdapterConfig<BrandDTO, CreateBrandDTO>.NewConfig().TwoWays();
            //}
        }
    }
}

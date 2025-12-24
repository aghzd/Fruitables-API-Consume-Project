using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Service.DTOs.Account;
using Service.DTOs.Basket;
using Service.DTOs.Category;
using Service.DTOs.Contact;
using Service.DTOs.Product;
using Service.DTOs.ProductImage;
using Service.DTOs.Service;
using Service.DTOs.SliderImage;
using Service.DTOs.SliderInfo;
using Service.DTOs.StatsCard;
using Service.DTOs.StoreFeature;

namespace Service.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<SliderImageCreateDto, SliderImage>();
            CreateMap<SliderImage, SliderImageDto>();
            CreateMap<SliderImageEditDto, SliderImage>();

            CreateMap<SliderInfoCreateDto, SliderInfo>();
            CreateMap<SliderInfo, SliderInfoDto>();
            CreateMap<SliderInfoEditDto, SliderInfo>();

            CreateMap<StoreFeatureCreateDto, StoreFeature>();
            CreateMap<StoreFeature, StoreFeatureDto>();
            CreateMap<StoreFeatureEditDto, StoreFeature>();

            CreateMap<CategoryCreateDto, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryEditDto, Category>();

            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<ProductEditDto, Product>();

            CreateMap<ProductImageCreateDto, ProductImage>();
            CreateMap<ProductImage, ProductImageDto>();
            CreateMap<ProductImageEditDto, ProductImage>();

            CreateMap<StatsCardCreateDto, StatsCard>();
            CreateMap<StatsCard, StatsCardDto>();
            CreateMap<StatsCardEditDto, StatsCard>();

            CreateMap<ProductOfferCreateDto, ProductOffer>();
            CreateMap<ProductOffer, ProductOfferDto>();
            CreateMap<ProductOfferEditDto, ProductOffer>();

            CreateMap<AppUser, UserDto>();
            CreateMap<IdentityRole, RoleDto>();

            CreateMap<BasketItem, BasketItemDto>()
               .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
               .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
               .ForMember(dest=>dest.Image,opt=>opt.MapFrom(src=>src.Product.ProductImages.FirstOrDefault(pi=>pi.IsMain==true).Name));

            CreateMap<Basket, BasketDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.BasketItems));

            CreateMap<ContactCreateDto, Contact>();
            CreateMap<Contact, ContactDto>();
        }
    }
}
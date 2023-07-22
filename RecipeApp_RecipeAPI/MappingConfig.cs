using AutoMapper;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Models.Dto;

namespace RecipeApp_RecipeAPI
{
    public class MappingConfig:Profile
    {
        public MappingConfig() 
        {

            CreateMap<RecipeDTO, RecipeCreateDTO>().ReverseMap();
            CreateMap<Recipe, RecipeCreateDTO>().ReverseMap();
            CreateMap<Recipe, RecipeDTO>().ReverseMap();

            CreateMap<RecipeIngredientDTO, RecipeIngredientCreateDTO>().ReverseMap();
            CreateMap<RecipeIngredient, RecipeIngredientCreateDTO>().ReverseMap();
            CreateMap<RecipeIngredient, RecipeIngredientDTO>().ReverseMap();

            CreateMap<CategoryDTO, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();

            CreateMap<IngredientDTO, IngredientCreateDTO>().ReverseMap();
            CreateMap<Ingredient, IngredientCreateDTO>().ReverseMap();
            CreateMap<Ingredient, IngredientDTO>().ReverseMap();

            CreateMap<RecipeTypeDTO, RecipeTypeCreateDTO>().ReverseMap();
            CreateMap<RecipeType, RecipeTypeCreateDTO>().ReverseMap();
            CreateMap<RecipeType, RecipeTypeDTO>().ReverseMap();

            CreateMap<CookTimeDTO, CookTimeCreateDTO>().ReverseMap();
            CreateMap<CookTime, CookTimeCreateDTO>().ReverseMap();
            CreateMap<CookTime, CookTimeDTO>().ReverseMap();

            CreateMap<RecipeReactionDTO, RecipeReactionCreateDTO>().ReverseMap();
            CreateMap<RecipeReaction, RecipeReactionCreateDTO>().ReverseMap();
            CreateMap<RecipeReaction, RecipeReactionDTO>().ReverseMap();

            CreateMap<ReactionDTO, ReactionCreateDTO>().ReverseMap();
            CreateMap<Reaction, ReactionCreateDTO>().ReverseMap();
            CreateMap<Reaction, ReactionDTO>().ReverseMap();

            CreateMap<RecipeReviewDTO, RecipeReviewCreateDTO>().ReverseMap();
            CreateMap<RecipeReview, RecipeReviewCreateDTO>().ReverseMap();
            CreateMap<RecipeReview, RecipeReviewDTO>().ReverseMap();

            CreateMap<RecipeInstructionDTO, RecipeInstructionCreateDTO>().ReverseMap();
            CreateMap<RecipeInstruction, RecipeInstructionCreateDTO>().ReverseMap();
            CreateMap<RecipeInstruction, RecipeInstructionDTO>().ReverseMap();

            CreateMap<CookDTO, CookCreateDTO>().ReverseMap();
            CreateMap<Cook, CookCreateDTO>().ReverseMap();
            CreateMap<Cook, CookDTO>().ReverseMap();

            CreateMap<CookFollowerDTO, CookFollowerCreateDTO>().ReverseMap();
            CreateMap<CookFollower, CookFollowerCreateDTO>().ReverseMap();
            CreateMap<CookFollower, CookFollowerDTO>().ReverseMap();

            CreateMap<UserDTO, UserCreateDTO>().ReverseMap();
            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<DietDTO, DietCreateDTO>().ReverseMap();
            CreateMap<Diet, DietCreateDTO>().ReverseMap();
            CreateMap<Diet, DietDTO>().ReverseMap();

            CreateMap<RoleDTO, RoleCreateDTO>().ReverseMap();
            CreateMap<Role, RoleCreateDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();

            CreateMap<PermissionDTO, PermissionCreateDTO>().ReverseMap();
            CreateMap<Permission, PermissionCreateDTO>().ReverseMap();
            CreateMap<Permission, PermissionDTO>().ReverseMap();
        }
    }
}

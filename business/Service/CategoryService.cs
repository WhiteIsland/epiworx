using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Service
{
    [Serializable]
    public class CategoryService
    {
        public static Category CategoryFetch(int categoryId)
        {
            return Category.FetchCategory(
                new CategoryCriteria
                    {
                        CategoryId = categoryId
                    });
        }

        public static CategoryInfoList CategoryFetchInfoList()
        {
            return CategoryService.CategoryFetchInfoList(
                new CategoryCriteria());
        }

        internal static CategoryInfoList CategoryFetchInfoList(CategoryCriteria criteria)
        {
            return CategoryInfoList.FetchCategoryInfoList(criteria);
        }

        public static Category CategorySave(Category category)
        {
            if (!category.IsValid)
            {
                return category;
            }

            Category result;

            if (category.IsNew)
            {
                result = CategoryService.CategoryInsert(category);
            }
            else
            {
                result = CategoryService.CategoryUpdate(category);
            }

            return result;
        }

        public static Category CategoryInsert(Category category)
        {
            return category.Save();
        }

        public static Category CategoryUpdate(Category category)
        {
            return category.Save();
        }

        public static Category CategoryNew()
        {
            return Category.NewCategory();
        }

        public static bool CategoryDelete(Category category)
        {
            Category.DeleteCategory(
                new CategoryCriteria
                    {
                        CategoryId = category.CategoryId
                    });

            return true;
        }

        public static bool CategoryDelete(int categoryId)
        {
            return CategoryService.CategoryDelete(
                CategoryService.CategoryFetch(categoryId));
        }
    }
}
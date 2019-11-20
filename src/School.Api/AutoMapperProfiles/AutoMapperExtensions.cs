using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace School.Api.AutoMapperProfiles
{
    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreMember<TDestination, TSource, TMember>(
            this IMappingExpression<TSource, TDestination> mapping, Expression<Func<TDestination, TMember>> destinationMember)
        {
            return mapping.ForMember(destinationMember, options => options.Ignore());
        }

        public static IMappingExpression<TSource, TDestination> MapMember<TDestination, TSource, TMember>(
            this IMappingExpression<TSource, TDestination> mapping,
            Expression<Func<TSource, TMember>> sourceMember,
            Expression<Func<TDestination, TMember>> destinationMember)
        {
            return mapping.ForMember(destinationMember, options => options.MapFrom(sourceMember));
        }
    }
}

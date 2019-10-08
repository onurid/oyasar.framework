using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace OYASAR.Framework.Mapper.AutoMapping
{
    public class AutoMapperManager : IAutoMapperManager
    {
        private IMapper _mapper;

        private IList<OrganizationProfile> list;

        public AutoMapperManager()
        {
            list = new List<OrganizationProfile>();
        }

        public T Map<T>(object dto)
        {
            return _mapper.Map<T>(dto);
        }

        public IQueryable<T> Map<T>(IQueryable query)
        {
            var projection = new ProjectionExpression(query, _mapper.ConfigurationProvider.ExpressionBuilder);

            var result = projection.To<T>();

            return result;
        }

        public void RegisterMap<T, K>()
        {
            list.Add(new OrganizationProfile(typeof(T), typeof(K)));

            var config = new MapperConfiguration(cfg =>
            {
                //cfg.AllowNullCollections = true;
                foreach (var item in list)
                    cfg.AddProfile(item);
            });

            _mapper = config.CreateMapper();
        }

        public void RegisterMap<T, K>(T model, K dto, Expression<Func<T, K>> expr)
        {
            throw new NotImplementedException();
        }

        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ADdresss Addr { get; set; }
        }

        public class UserDto
        {
            public string Name { get; set; }
            public ADdresss Addr { get; set; }
        }

        public class ADdresss
        {
            public string State { get; set; }
        }

        public class OrganizationProfile : Profile
        {
            public OrganizationProfile(Type sourceP, Type destinationP)
            {
                CreateMap(sourceP, destinationP).ForAllMembers(opt => opt.Condition(
        (source, destination, sourceMember, destMember) => (sourceMember != null)));

                
                //.ForAllMembers(opt => opt.Condition(srs => !srs.IsSourceValueNull));

            }
        }
    }
}
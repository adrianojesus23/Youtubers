using App.IfElseResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.MapperExtensions
{
    public static class MapperExtension
    {
        public static TDestination Mapper<TSource,TDestination>(this TSource source)
            where TDestination : new()
        {
            if( source is null)
                throw new ArgumentNullException(nameof(source));

             TDestination destination = new TDestination();

            foreach(var sourceProperty in typeof(TSource).GetProperties())
            {
                var destinationProperty = typeof(TDestination).GetProperty(sourceProperty.Name);

                if( destinationProperty is not null && destinationProperty.CanWrite)
                {
                    var value = sourceProperty.GetValue(source);
                    destinationProperty.SetValue(destination, value);
                }
            }

            return destination;
         }
    }
}

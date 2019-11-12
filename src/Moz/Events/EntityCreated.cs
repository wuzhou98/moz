﻿using Moz.Bus.Models;
using Moz.CMS.Models;
using Moz.CMS.Model;
using Moz.CMS.Models;
using Moz.Domain.Models;

namespace Moz.Events
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityCreated<T> where T : BaseModel
    {
        public EntityCreated(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; }
    }
}
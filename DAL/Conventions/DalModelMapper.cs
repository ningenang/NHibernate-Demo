using DAL.Extensions;
using NHibernate.Mapping.ByCode;
using System;
using System.Linq;

namespace DAL.Conventions
{
	public class DalModelMapper : ConventionModelMapper
	{
		private const string _foreignKeyColumnPostfix = "ID";
		private Type _baseEntityType;

		public DalModelMapper(Type baseEntityType)
		{
			_baseEntityType = baseEntityType;

			BeforeMapJoinedSubclass += DefaultSubclassMapper;
			BeforeMapClass += DefaultClassMapper;
			BeforeMapProperty += DefaultPropertyMapper;
			BeforeMapManyToOne += DefaultMapManyToOne;
			BeforeMapList += DefaultMapCollection;
			BeforeMapSet += DefaultMapCollection;
			BeforeMapBag += DefaultMapCollection;
			BeforeMapList += DefaultMapCollection;
			BeforeMapIdBag += DefaultMapCollection;
			BeforeMapMap += DefaultMapCollection;
			BeforeMapOneToOne += DefaultMapOneToOne;

			IsEntity(_isEntity);
			IsRootEntity(_isRootEntity);
		}

		private bool _isEntity(Type type, bool declared)
		{
			return _baseEntityType.IsAssignableFrom(type) &&
					type != _baseEntityType;
		}

		private bool _isRootEntity(Type type, bool declared)
		{
			return _baseEntityType == type.BaseType;
		}

		private void DefaultMapOneToOne(IModelInspector inspector, PropertyPath member, IOneToOneMapper mapper)
		{
		}

		private void DefaultMapManyToOne(IModelInspector inspector, PropertyPath member, IManyToOneMapper customizer)
		{
			customizer.Column(member.LocalMember.Name + _foreignKeyColumnPostfix);
		}

		private void DefaultMapCollection(IModelInspector inspector, PropertyPath member, ICollectionPropertiesMapper customizer)
		{
			customizer.Key(k => k.Column(DetermineKeyColumnName(inspector, member)));
		}

		private static string DetermineKeyColumnName(IModelInspector inspector, PropertyPath member)
		{
			var otherSideProperty = member.OneToManyOtherSideProperty();
			if (inspector.IsOneToMany(member.LocalMember) && otherSideProperty != null)
			{
				return otherSideProperty.Name + _foreignKeyColumnPostfix;
			}

			return member.Owner().Name + _foreignKeyColumnPostfix;
		}

		public static void DefaultSubclassMapper(IModelInspector modelInspector, Type type, IJoinedSubclassAttributesMapper mapper)
		{
			MapSchema(mapper.Schema, type);

			mapper.Key(key =>
			{
				key.Column(type.BaseType.Name + _foreignKeyColumnPostfix);
			});
		}

		private static void MapSchema(Action<string> schemaMapper, Type type)
		{
			string[] elements = type.Namespace.Split('.');

			if (elements.Last() != "Mapping")
			{
				schemaMapper(elements.Last());
			}
		}

		public static void DefaultClassMapper(IModelInspector modelInspector, Type type, IClassAttributesMapper mapper)
		{
			MapSchema(mapper.Schema, type);

			mapper.Id(id =>
			{
				id.Column(type.Name + _foreignKeyColumnPostfix);
				id.Generator(Generators.Identity);
			});
		}

		public static void DefaultPropertyMapper(IModelInspector modelInspector, PropertyPath path, IPropertyMapper mapper)
		{
			if (path.LocalMember.GetPropertyOrFieldType() == typeof(bool))
			{
				mapper.Column(path.ToColumnName() + "Flag");
			}
		}
	}
}

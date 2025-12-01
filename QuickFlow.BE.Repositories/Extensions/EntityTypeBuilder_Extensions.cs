using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using QuickFlow.BE.Shared.Extensions;
using QuickFlow.BE.Entities;

namespace QuickFlow.BE.Repositories.Extensions
{
	public static class EntityTypeBuilder_Extensions
	{
		/// <summary>
		/// Sets the default database values for properties in <see cref="BaseApplicationTable"/>.
		/// </summary>
		/// <remarks>
		/// Sets default SQL values for properties such as <c>RowId</c>, <c>CreatedAt</c>, <c>LastModifiedAt</c>, and soft deletion flags.
		/// </remarks>
		/// <typeparam name="ApplicationTableType">The entity type that inherits from <see cref="BaseApplicationTable"/>.</typeparam>
		/// <param name="entModelBuilder">The entity builder used to configure the entity.</param>
		/// <returns>
		/// The same <see cref="EntityTypeBuilder"/> instance, to allow for fluent configuration.
		/// </returns>
		internal static EntityTypeBuilder<ApplicationTableType> SetApplicationTableDefault<ApplicationTableType>(this EntityTypeBuilder<ApplicationTableType> entModelBuilder)
			where ApplicationTableType : BaseApplicationTable
			=> entModelBuilder
				.SetApplicationTableColumnDefault(e => e.RowId, "gen_random_uuid()")
				.SetApplicationTableColumnDefault(e => e.CreatedAt, "now()")
				.SetApplicationTableColumnDefault(e => e.LastModifiedAt, "now()")
				.SetApplicationTableColumnDefault(e => e.IsDeleted, "false");

		/// <summary>
		/// Sets the default database values for properties in <see cref="BaseApplicationTable"/>.
		/// </summary>
		/// <remarks>
		/// Sets default SQL values for properties such as <c>RowId</c>, <c>CreatedAt</c>, <c>LastModifiedAt</c>, and soft deletion flags.
		/// </remarks>
		/// <typeparam name="ApplicationTableType">The entity type that inherits from <see cref="BaseApplicationTable"/>.</typeparam>
		/// <param name="entModelBuilder">The entity builder used to configure the entity.</param>
		/// <returns>
		/// The same <see cref="EntityTypeBuilder"/> instance, to allow for fluent configuration.
		/// </returns>
		internal static EntityTypeBuilder<ApplicationTableType> SetApplicationTableColumnDefault<ApplicationTableType, PropertyType>(this EntityTypeBuilder<ApplicationTableType> entModelBuilder, Expression<Func<ApplicationTableType, PropertyType>> propertyExpression, string defaultValue)
			where ApplicationTableType : BaseApplicationTable
		{
			_ = entModelBuilder.Property(propertyExpression).HasDefaultValueSql(defaultValue);
			return entModelBuilder;
		}

		/// <summary>
		/// Sets seed data for the specified entity type.
		/// </summary>
		/// <remarks>
		/// This method wraps <see cref="EntityTypeBuilder.HasData(object[])"/> to set seed data using a strongly typed collection.
		/// </remarks>
		/// <typeparam name="TableType">The entity type that inherits from <see cref="BaseApplicationTable"/>.</typeparam>
		/// <param name="entModelBuilder">The entity builder used to configure the entity.</param>
		/// <param name="seedData">The collection of seed data records to apply to the entity.</param>
		/// <returns>
		/// The same <see cref="EntityTypeBuilder"/> instance, allowing for fluent configuration.
		/// </returns>
		public static EntityTypeBuilder<TableType> SetSeedData<TableType>(this EntityTypeBuilder<TableType> entModelBuilder, IEnumerable<TableType> seedData)
			where TableType : BaseTable
		{
			_ = entModelBuilder.HasData(seedData);
			return entModelBuilder;
		}
	}
}

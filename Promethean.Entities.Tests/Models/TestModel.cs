using System;
using Promethean.Entities.Models;
using Promethean.Entities.Models.Configurations.Builders;
using Promethean.Entities.Tests.Entities;

namespace Promethean.Entities.Tests.Models
{
	public class TestModel : Model<TestEntity, TestModel>
	{
		public Guid? Id { get; private set; }

		public string Name { get; set; }
		public string Email { get; set; }
		public DateTime? Birthdate { get; set; }

		public int Age { get; private set; }

		public DateTime? CreatedAt { get; private set; }

		public void SetId(Guid id) => Id = id;

		protected override void OnBuild(ModelConfigurationBuilder<TestEntity, TestModel> builder)
		{
			builder.EntityProperty(entity => entity.Id)
		  		.HasModelProperty(model => model.Id);

			builder.EntityProperty(entity => entity.Name)
				.HasModelProperty(model => model.Name);

			builder.EntityProperty(entity => entity.Email)
				.HasModelProperty(model => model.Email);

			builder.EntityProperty(entity => entity.Birthdate)
				.HasModelProperty(model => model.Birthdate);

			builder.ModelProperty(model => model.Age)
				.ModelOnly()
				.GetEntityValue(entity => new DateTime(DateTime.Today.Subtract(entity.Birthdate).Ticks).Year);

			builder.ModelProperty(model => model.CreatedAt)
				.HasEntityProperty(entity => entity.CreatedAt)
				.IsModelOnly();
		}
	}
}
// using Swashbuckle.AspNetCore.Annotations;
//
// namespace models
// {
//     public class TaskRequestModel
//     {
//         [SwaggerSchema(Title = "Nome", Description = "Nome da Tarefa")]
//         public string? Name { get; set; }
//
//         [SwaggerSchema(Title = "Data de Conclusão", Description = "Quando a Tarefa foi finalizada")]
//         public DateTime? ConclusionDate { get; set; }
//
//         [SwaggerSchema(Title = "Concluída", Description = "Se a Tarefa foi finalizada")]
//         public bool? Finished { get; set; }
//         public TaskModel ConvertToTaskModel()
//         {
//             return new TaskModel { Name = Name, ConclusionDate = ConclusionDate, Finished = Finished };
//         }
//     }
// }
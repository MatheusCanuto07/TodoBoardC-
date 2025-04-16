namespace TODO.Views.Shared.Components.Card;

public class CardViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public List<TagViewModel> Tags { get; set; } = [];
    public int Number { get; set; }
    public Uri PerfilPhoto { get; set; }

}

public class TagViewModel
{
    public string Name { get; set; }
    public string Color => Name switch
    {
        "doing" => "primary",
        "done" => "success",
        "pending" => "warning",
        "canceled" => "danger",
        _ => "default" // Cor padrão se não for nenhuma das anteriores
    };
}
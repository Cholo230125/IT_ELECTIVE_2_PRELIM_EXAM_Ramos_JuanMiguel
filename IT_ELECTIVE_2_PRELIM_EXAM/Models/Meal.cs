namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

// EXERCISE 1: Encapsulation - Private Fields
// The fields below are public. Your task:
// - Make all fields PRIVATE
// - Create public Properties with getters and setters
// - The property names should match the field names (PascalCase)
//
// Currently, the properties below are STUBS that return wrong values.
// Fix them to properly wrap the private fields.

public class Meal
{
    private string _name;
    private string _category;
    private string _area;
    private string _instructions;
    private string _thumbnail;
    private string _tags;

    // EXERCISE 1: Fix these stub properties to properly get/set from private fields
    // After fixing, make the fields above PRIVATE
    public string Name
    {
        get => _name;
        set => _name = value;
    }
    public string Category
    {
        get => _category;
        set => _category = value;
    }
    public string Area
    {
        get => _area;
        set => _area = value;
    }

    public Meal()
    {
        _name = "";
        _category = "";
        _area = "";
        _instructions = "";
        _thumbnail = "";
        _tags = "";
    }

    public Meal(string name, string category, string area)
    {
        this._name = name;
        this._category = category;
        this._area = area;
        this._instructions = "";
        this._thumbnail = "";
        this._tags = "";
    }

    public override string ToString()
    {
        return $"Meal: {Name} | Category: {Category} | Area: {Area}";
    }
}
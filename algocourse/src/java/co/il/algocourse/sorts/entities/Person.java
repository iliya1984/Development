package co.il.algocourse.sorts.entities;

public class Person
{
    private String firstName;
    private String lastName;
    private int height;
    private int weight;

    public Person() {
    }

    public  String getFirstName()
    {
        return firstName;
    }

    public  void setFirstName(String value)
    {
        firstName = value;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public int getHeight() {
        return height;
    }

    public void setHeight(int height) {
        this.height = height;
    }

    public int getWeight() {
        return weight;
    }

    public void setWeight(int weight) {
        this.weight = weight;
    }
}

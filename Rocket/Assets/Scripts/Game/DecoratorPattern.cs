using UnityEngine;

abstract class RocketVisuals
{

    public abstract void Display();
    public abstract RocketVisuals Remove();
}
class BaseRocket : RocketVisuals
{
    GameObject rocketImage;

    public BaseRocket(GameObject rocketImage) {this.rocketImage = rocketImage;}
    public override void Display()
    {
        rocketImage.SetActive(true);
    }
    public override RocketVisuals Remove()
    {
        rocketImage.SetActive(false);
        return null;
    }
}
class RocketDecorator : RocketVisuals
{
    public RocketVisuals component;
    public RocketDecorator(RocketVisuals component) { this.component = component; }
    public override void Display() { component.Display(); }
    public override RocketVisuals Remove() { return component.Remove(); }
}


class ExhaustDecorator : RocketDecorator
{
    GameObject exhaustImage;
    public ExhaustDecorator(RocketVisuals component, GameObject exhaustImage) : base(component) { this.exhaustImage = exhaustImage; }
    public override void Display()
    {
        base.Display();
        DisplayExhaust();
    }
    private void DisplayExhaust()
    {
        exhaustImage.SetActive(true);
    }
    public override RocketVisuals Remove()
    {
        exhaustImage.SetActive(false);
        return component;
    }
}
class ForcefieldDecorator : RocketDecorator
{
    GameObject forcefieldImage;
    public ForcefieldDecorator(RocketVisuals component, GameObject forcefieldImage) : base(component) { this.forcefieldImage = forcefieldImage; }
    public override void Display()
    {
        base.Display();
        DisplayForcefield();
    }
    private void DisplayForcefield()
    {
        forcefieldImage.SetActive(true);
    }
    public override RocketVisuals Remove()
    {
        forcefieldImage.SetActive(false);
        return component;
    }
}
class MagnetDecorator : RocketDecorator
{
    GameObject magnetImage;
    public MagnetDecorator(RocketVisuals component, GameObject magnetImage) : base(component) { this.magnetImage = magnetImage; }
    public override void Display()
    {
        base.Display();
        DisplayMagnet();
    }
    private void DisplayMagnet()
    {
        magnetImage.SetActive(true);
    }
    public override RocketVisuals Remove()
    {
        magnetImage.SetActive(false);
        return component;
    }
}
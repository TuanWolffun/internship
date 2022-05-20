public class Rocket4 : Rocket3
{
    protected new void OldGiaiDoan1(){base.GiaiDoan1();}
    protected new void OldGiaiDoan2(){base.GiaiDoan2();}
    protected new void OldGiaiDoan3(){base.GiaiDoan3();}

    protected override void GiaiDoan1(){base.OldGiaiDoan1();}
    protected override void GiaiDoan2(){base.OldGiaiDoan2();}    
}

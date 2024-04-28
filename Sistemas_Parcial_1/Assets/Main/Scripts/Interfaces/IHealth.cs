using System.Collections;
using System.Collections.Generic;

public interface IHealth 
{
    void UpdateHealth();

    void GetDamage(int damage);

    void Heal(int heal);
       
    void Death();

    bool IsAlive();

}

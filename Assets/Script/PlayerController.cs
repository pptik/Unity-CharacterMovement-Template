using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 2;
    public float runSpeed = 6;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // input X dan Y 
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // menyimpan input vector2 yang belum dirubah
        Vector2 inputDir = input.normalized;
        
        if (inputDir != Vector2.zero)
        {
            // membuat karakter berotasi berdasarkan input keyboard
            transform.eulerAngles = Vector3.up * Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;

        }
        // memerikasa apakah ada input dari tombol Shift? 
        bool running = Input.GetKey(KeyCode.LeftShift);
        // jika tombol shift ditekan maka akan menjalankan kecepatan runSpeed jika tidak maka menjalankan walkspeed
        // input magnitude mengembalikan nilai vector
        float speed = ((running) ? runSpeed : walkSpeed) * input.magnitude;
        // membuat karakter berjalan pada world yang sudah di buat
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        // mengatur jika sedang running maka animationSpeedPercent akan berubah menjadi 1 jika tidak maka akan 0.5 
        float animationSpeedPercent = ((running) ? 1 : .5f) * inputDir.magnitude;
        // merubah parameter AnimatorController sesuai dengan animationSpeedPercent
        animator.SetFloat("speedPercent", animationSpeedPercent);

    }
}

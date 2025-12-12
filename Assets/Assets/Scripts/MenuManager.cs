using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "Restart")
        {
            Debug.Log("Restart Button Clicked");
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
            Time.timeScale = 1f; // Đảm bảo thời gian được đặt lại về bình thường
        }
        else if (gameObject.name == "Mainmenu")
        {
            Debug.Log("Home Button Clicked");
            SceneManager.LoadScene("Home");
            Time.timeScale = 1f; // Đảm bảo thời gian được đặt lại về bình thường
        }
        else if (gameObject.name == "Nextlevel")
        {
            // Lấy tên scene hiện tại
            string currentSceneName = SceneManager.GetActiveScene().name;
            // Xác định tên scene tiếp theo (giả sử các scene được đặt tên theo thứ tự như Level1, Level2, ...)
            string nextSceneName = "Level" + (int.Parse(currentSceneName.Replace("Level", "")) + 1).ToString();
            // Kiểm tra xem scene tiếp theo có tồn tại không trước khi tải
            if (Application.CanStreamedLevelBeLoaded(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }

            else
        {
            Debug.Log("Không có cấp độ tiếp theo. Hoặc bạn đã hoàn thành tất cả các cấp độ!");
            // Bạn có thể thêm logic để xử lý khi không còn cấp độ nào nữa
        }
        }
        else if (gameObject.name == "Startgame")
        {
            SceneManager.LoadScene("Level1");
        }
        else if (gameObject.name == "Instruction")
        {
            SceneManager.LoadScene("Instruction");
        }
        else if (gameObject.name == "Backtohome")
        {
            SceneManager.LoadScene("Home");
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boomlagoon.JSON;
using System;

/* UserSingleton클래스는 현재 유저의 개인 정보 및 능력치 정보를 메모리 상에 들고 있는 싱글톤 클래스 입니다.
   서버로부터 /User/{유저아이디} API로 정보를 가져와서 여기에 저장합니다.
 */

 using Facebook;
 using Facebook.Unity;
public class UserSingleton : MonoBehaviour {

	// UserID입니다. 서버 상에서 유저를 식별하는 고유번호입니다.
	public int UserID{
		get{
			return PlayerPrefs.GetInt("UserID");
		}
		set{
			PlayerPrefs.SetInt("UserID", value);
		}
	}

	// AccessToken은 서버 API에 접근하기 위한 API의 역할을 합니다.
	public string AccessToken{
		get{
			return PlayerPrefs.GetString("AccessToken");
		}
		set{
			PlayerPrefs.SetString("AccessToken", value);
		}
	}

	// 페이스북 아이디입니다. 페이스북의 고유번호입니다. App Scoped User ID입니다.
	public string FacebookID{
		get{
			return PlayerPrefs.GetString("FacebookID");
		}
		set{
			PlayerPrefs.SetString("FacebookID", value);
		}
	}

	// 페이스북에 인증할 수 있는 유저의 개인 비밀번호 키입니다.
	public string FacebookAccessToken{
		get{
			return PlayerPrefs.GetString("FacebookAccessToken");
		}
		set{
			PlayerPrefs.SetString("FacebookAccessToken", value);
		}
	}

	// 유저의 이름입니다. 기본적으로 페이스북의 이름을 가져와 적용합니다.
	public string Name{
		get{
			return PlayerPrefs.GetString("Name");
		}
		set{
			PlayerPrefs.SetString("Name", value);
		}
	}

	// 페이스북의 프로필 사진 주소입니다.
	public string FacebookPhotoURL{
		get{
			return PlayerPrefs.GetString("FacebookPhotoURL");
		}
		set{
			PlayerPrefs.SetString("FacebookPhotoURL", value);
		}
	}

	// 유저의 레벨, 경험치, 체력, 방어력, 스피드, 데미지 레벨, 체력 레벨, 방어력 레벨, 스피드 레벨입니다.
	// 다음 레벨까지 남은 경험치, 그리고 다음 레벨로 레벨업하기 위해 필요한 경험치 정보도 가지고 있습니다.
	public int
		level, Experience, Damage, Health, Defence, Speed,
		DamageLevel, HealthLevel, DefenceLevel, SpeedLevel, 
		Diamond, ExpAfterLastLevel, ExpForNextLevel;

	public JSONArray FriendList;
	static UserSingleton _instance;
	public static UserSingleton Instance{
		get{
			if(!_instance){
				GameObject container = new GameObject("UserSingleton");
				_instance = container.AddComponent(typeof(UserSingleton)) as UserSingleton;
				DontDestroyOnLoad(container);
			}
			return _instance;
		}
	}

	public void FacebookLogin(Action<bool, string> callback, int retryCount = 0)
	{
		/* 
		FB.Login("email", delegate(FBResult result) {

		});
		*/
	}

/* 
	private void CallFBLogin()
	{
		FB.LogInWithReadPermissions(new List<string>() { "public_profile", "email", "user_friends" }, this.HandleResult);
	}

	private void CallFBLoginForPublish()
	{
		// It is generally good behavior to split asking for read and publish
		// permissions rather than ask for them all at once.
		//
		// In your own game, consider postponing this call until the moment
		// you actually need it.
		FB.LogInWithPublishPermissions(new List<string>() { "publish_actions" }, this.HandleResult);
	}
	*/

	/* 
	public void LoginFacebook()
    {
        FB.Init(delegate() {
            FB.LogInWithReadPermissions(
                new List<string>() { "public_profile", "email", "user_friends" }, 
                delegate(ILoginResult result) {
                    Debug.Log(result.RawResult);
                    string user_id = result.ResultDictionary["user_id"].ToString();
                    string photo_url = "http://graph.facebook.com/" + user_id + "/picture?type=square";
                    Debug.Log(user_id);
                    Debug.Log(photo_url);

                    FB.API("/me", HttpMethod.GET, delegate (IGraphResult meResult)
                    {
                        Debug.Log(meResult.RawResult);
                        string facebook_Name = meResult.ResultDictionary["name"].ToString();
                        Debug.Log("Facebook name : " + facebook_Name);
                    });

                    FB.API("/me/friends", HttpMethod.GET, delegate (IGraphResult friendResult)
                    {
                        Debug.Log(friendResult.RawResult);
                        FriendResult res = JsonUtility.FromJson<FriendResult>(friendResult.RawResult);
                        Debug.Log(res.summary.total_count);
                        
                    });
                });
        	});
    	}
	}
	*/
}

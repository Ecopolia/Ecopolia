using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;


public class login {

    public void Start() {
      PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    internal void ProcessAuthentication(SignInStatus status) {
      if (status == SignInStatus.Success) {
        // Continue with Play Games Services
      } else {
        // Disable your integration with Play Games Services or show a login button
        // to ask users to sign-in. Clicking it should call
        // PlayGamesPlatform.Instance.ManuallyAuthenticate(ProcessAuthentication).
      }
    }
}

# MessageniusSDK

## On Andriod 
  initialize package before LoadApplication(new App());
  ```
  MessageniusSDK.Android.Messagenius.Init();
  ```
  
## On IOS
  initialize package before LoadApplication(new App());
  ```
  MessageniusSDK.iOS.Messagenius.Init();
  ```
  
## Functions
  
### Init
  ```
  Messagenius.Current.Init(ApplicationId,Server,WindowsKey);
  ```
 
### Login
  ```
  Messagenius.Current.LoginAsync(Username, Password);
  ```
  
### Signup
  ```
  Messagenius.Current.SignUpAsync(Username, Email, Password);
  ```
  
### OFSendEvent
  ```
  Messagenius.Current.OFSendEvent(Type, Order, RoomId, LocationEnabled, startUtcTime.ToUnixTimeSeconds(), endUtcDate.ToUnixTimeSeconds(), Username);
  ```
  
### OFSendPosition
  ```
  Messagenius.Current.OFSendPosition(Order,RoomId,Latitude,Longitude);
  ```
  
### OFCheckinStatus
  ```
  Messagenius.Current.OFCheckinStatus(Order,RoomId,keyToCheck);
  ```
  
### OFRegisterToken
  ```
  Messagenius.Current.OFRegisterToken(Token,Device,Username);
  ```
  
### OFUnregisterToken
  ```
  Messagenius.Current.OFUnregisterToken(Username);
  ```
  
### ClearSession
  ```
  Messagenius.Current.ClearSession();
  ```
  
### Logout
  ```
  Messagenius.Current.LogOut();
  ```

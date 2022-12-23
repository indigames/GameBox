mergeInto(LibraryManager.library, {

  _GameStart: function () {
    window.GameStart();
  },

  _GameEnd: function (score) {
    window.GameEnd(score);
  },

  _GameSave: function (data) {
    window.GameSave(Pointer_stringify(data));
  },

  _GameGetData: function () {
    window.GameGetData();
  },

  _ShowRewardAd: function () {
    window.ShowRewardAd();
  },

  _DebugOut: function (str) {
    window.alert(Pointer_stringify(str));
  },



});

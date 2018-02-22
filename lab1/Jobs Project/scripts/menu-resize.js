$(document).ready(function() {
  $('#menu-bar').click(function(){
    if($('#hidden-menu').css('display') == "none") {
    $('#hidden-menu').slideDown();
    } else {
      $('#hidden-menu').slideUp();
    }
  })
});

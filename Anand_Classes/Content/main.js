window.addEventListener('scroll',function(){
    var navbar = document.getElementById('header');
    if(window.scrollY > 250){
        navbar.style.backdropFilter = "blur(50px)";
        navbar.style.transition='1s';
    }
    else{
        navbar.style.background='transparent';
    }
});


// code for about

$('.features-item').on('click', function () {
    var $this = $(this);
    var imgsrc = $this.attr('data-src');

    $('.features-image img').attr('src', imgsrc);
});



    $(document).ready(function () {
        //FANCYBOX
        //https://github.com/fancyapps/fancyBox
        $(".fancybox").fancybox({
            openEffect: "none",
            closeEffect: "none"
        });
    });



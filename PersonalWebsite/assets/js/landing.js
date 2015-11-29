
$(document).ready(function(){


	$(".orangeBorder").hover(
		function() {
		$(".landingHeader").stop().animate({"color": "#FF5108"}, "slow");
		$("#orangeText").stop().animate({"color": "#FF5108"}, "slow");
		},
		function() {
		$(".landingHeader").stop().animate({"color": "#888"}, "slow");
		$("#orangeText").stop().animate({"color": "#888"}, "slow");
	});


	$(".tealBorder").hover(
		function() {
		$(".landingHeader").stop().animate({"color": "#50C0EE"}, "slow");
		$("#tealText").stop().animate({"color": "#50C0EE"}, "slow");
		},
		function() {
		$(".landingHeader").stop().animate({"color": "#888"}, "slow");
		$("#tealText").stop().animate({"color": "#888"}, "slow");
	});


$("#orangeText").hover(
		function() {
		$(".landingHeader").stop().animate({"color": "#FF5108"}, "slow");
		$("#orangeText").stop().animate({"color": "#FF5108"}, "slow");
		},
		function() {
		$(".landingHeader").stop().animate({"color": "#888"}, "slow");
		$("#orangeText").stop().animate({"color": "#888"}, "slow");
	});

	$("#tealText").hover(
		function() {
		$(".landingHeader").stop().animate({"color": "#50C0EE"}, "slow");
		$("#tealText").stop().animate({"color": "#50C0EE"}, "slow");
		},
		function() {
		$(".landingHeader").stop().animate({"color": "#888"}, "slow");
		$("#tealText").stop().animate({"color": "#888"}, "slow");
	});


});
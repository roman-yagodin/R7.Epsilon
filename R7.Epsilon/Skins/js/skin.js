﻿function skin_gtranslate (fromLang) {
    window.open ("http://translate.google.com/translate?hl=en&sl=" + fromLang + "&u=" + encodeURI (document.location));
}

$(function() {
    skin_init_search ();
    skin_init_breadcrumb ();
    skin_init_localmenu ();
    skin_init_modulesmenu ();
    skin_init_upbutton ();
    skin_init_tooltips ();
});

function skin_init_breadcrumb () {
    var breadcrumb = $(".breadcrumb > span").first ();
    var links = breadcrumb.children ("a").length;

    if (links === 1) {
        // hide parent container
        breadcrumb.parent ().parent ().hide ();
    }
    else {
        // remove last link
        breadcrumb.children ("a").last ().remove ();    
    }
}

function skin_init_search () {
    // "Bootstrapify" search
    var search = $(".skin-search > span").first ();
    search.children (".searchInputContainer").attr("style", "display:table-cell !important")
        .children ("input").removeClass ("NormalTextBox").addClass ("form-control");
    search.children ("a").removeClass ("SkinObject").addClass ("btn btn-default");
    search.show ();
}

function skin_init_localmenu () {
    var localMenu = $(".skin-local-menu").first ();
    if (localMenu.find (".sub").length === 0)
        localMenu.hide ();
}

function skin_init_modulesmenu () {
    var li0 = $('.skin-headers-menu ul#dnn_menuHeaders li.level0').first();
    li0.append ('<div class="sub"><ul></ul></div>');
    var pageContents = li0.find ('ul').first();
    var thisH = pageContents.parents('.DnnModule').find('h2,h3,h4').first();
    $('h2,h3,h4').each(function () {
        if (!$(this).is(thisH)) {
            var title = $(this).text().trim();
            var id = $(this).parents('.DnnModule').find('a').first().attr('name');
            if (id && title) {
                pageContents.append('<ul><li><a href="#' + id + '">' + title + '</a></li><ul>');
            }
        }
    });
}

// Up Button
function skin_init_upbutton () {
    var offset = 320;
    var duration = 500;
    jQuery(window).scroll(function() {
        if (jQuery(this).scrollTop() > offset) {
            jQuery('.skin-float-button-up').fadeIn(duration);
        } else {
            jQuery('.skin-float-button-up').fadeOut(duration);
        }
    });
    
    jQuery('.skin-float-button-up').click(function(event) {
        event.preventDefault();
        jQuery('html, body').animate({scrollTop: 0}, duration);
        return false;
    });
}

// init tooltips
function skin_init_tooltips () {
  $('[data-toggle="tooltip"]').tooltip();
}

// Feedback Button
function skin_feedback_button (obj, feedbackTabId, activeTabId) {
    $(obj).attr ("href", "/Default.aspx?tabid=" + feedbackTabId + "&errortabid=" + activeTabId);
    var errorContext = encodeURIComponent (rangy.getSelection ().toString ().replace (/(\n|\r)/gm," ").replace (/\s+/g, " ").replace (/\"/g, "").trim ().substring (0,100));
    if (!!errorContext)
        $(obj).attr ("href",  $(obj).attr ("href") + "&errorcontext=" + errorContext);
    return true;
}

/*
$(function() {
    $("body").mouseup (function(event) {
        if (rangy.getSelection ().toString())
        {
            var duration = 500;
            $(".skin-float-button-feedback").fadeIn(duration);
        }
        else
            $(".skin-float-button-feedback").fadeOut(duration);
    })
});
*/
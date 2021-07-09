// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const addSpeaker = document.getElementById('add-speaker');
/*const removeSpeaker = document.getElementById('remove-speaker');*/
const divElement = document.getElementById('speakers');



function addSpeakerInput() {
    var div = document.createElement('div');
    div.innerHTML = '<div class="form-row my-2"><div class="col-md-4" ><input placeholder="Topic" class="form-control" name="Topic" /></div ><div class="col-md-6"><input placeholder="Speaker Name" class="form-control" name="Speaker" /></div><div class="col-md-2 speaker-add"><button type="button" class="btn btn-outline-danger btn-sm" id="remove-speaker" onClick="removeSpeaker(this);">Remove</button></div></div >'
    document.getElementById("speakers").append(div);
}
function removeSpeaker(element) {
    const el = element.closest('.my-2')
    el.remove();
}


addSpeaker.addEventListener('click', addSpeakerInput);






// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const addSpeaker = document.getElementById('add-speaker');
/*const removeSpeaker = document.getElementById('remove-speaker');*/
const divElement = document.getElementById('speakers');


const options = document.querySelectorAll('.openingHymnSelect');
const intermediate = document.querySelectorAll('.intermediateHymnSelect');
const closing = document.querySelectorAll('.closingHymnSelect');



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


function removeSpeakerWID(speakerId) {
    let controls = document.querySelectorAll(`[data-id="${speakerId}"]`);

    controls.forEach(
        control => {
            control.remove();
        });
}

fetch('https://cdn.statically.io/gh/pseudosavant/LDSHymns/c3a00214e2f879a855f5894b345596dd6c547b70/hymns.json')
    .then(response => response.json())
    .then(results => {
        createOptions(results)
    })
    .catch(error => {
        console.log(error);
    })

function  createOptions(results)
{

    Object.keys(results).map(hymn => {
        console.log(results[hymn].name);
        return (options.forEach(option => {
            option.innerHTML += createHTML(results[hymn].name)
        }),
            intermediate.forEach(inter => {
                inter.innerHTML += createHTML(results[hymn].name)
            }),
            closing.forEach(close => {
                close.innerHTML += createHTML(results[hymn].name)
            })
            
            
           
        )
    })

}

function createHTML(name)
{
    return `<option value="${name}">${name}</option>`
}



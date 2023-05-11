async function encode(){
    const url = "api/base64/encode";
    const response = await sendData(url);
    await updateOutputFromResponse(response);
};

async function decode(){
    const url = "api/base64/decode";
    const response = await sendData(url);
    await updateOutputFromResponse(response);
}

function swapTextAreas(){
    let input = document.getElementById('input');
    let output = document.getElementById('output');

    const temp = input.value;
    input.value = output.value;
    output.value = temp;
}

function copyInput(){
    copyValueToClipboard(document.getElementById("input"));
}

function copyOutput(){
    copyValueToClipboard(document.getElementById("output"));
}

function copyValueToClipboard(element){
    element.select();
    element.setSelectionRange(0, 99999);
    document.execCommand("copy");
}

function convertTextToBytes(text){
    return new TextEncoder().encode(text);
}

async function sendData(url){
    const data = convertTextToBytes(document.getElementById("input").value);

    return await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/octet-stream"
        },
        body: data
    });
}

async function updateOutputFromResponse(response){
    const json = await response.json();
    document.getElementById("output").value = json.result;
}

// Elements
function getInput() => document.getElementById("intput");
function getOutput() => document.getElementById("output");

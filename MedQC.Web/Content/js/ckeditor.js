
var editor = null;
function initeditor() {
  
    editor = CKEDITOR.replace('Content', {
        toolbar: 'Standard',
        height:300
    });
    CKFinder.setupCKEditor(editor, '/Scripts/ckfinder/');   // 为编辑器绑定"上传控件"
}
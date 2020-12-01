// import { createApiPost, deletePostById, editApiPostById, getApiPostById } from "../data.js";
// import { showError, showInfo } from "../notification.js";
// import { errorHandler, getUser, preloadPartials } from "./util.js";


// export async function createPost(context) {

    // let post = Object.assign({}, context.params)
    // post._ownerId = getUser().localId;

    // try {
        // let response = await createApiPost(post)
        // showInfo('Sucessfully created post!')
        // context.redirect('/home')

    // } catch (error) {
        // showError('The post is not created!')
    // }

// }

// export async function detailsPage(context) {
    // try {
        // let post = await getApiPostById(getUser().localId, context.params._id)
        // if (post._ownerId == getUser().localId) {  //just in case :)
            // Object.assign(context, getUser(), post)
            // await preloadPartials(context)
            // this.partial('/templates/details.hbs')
        // }

    // } catch (error) {
        // showError('Error')
    // }


// }

// export async function editPostPage(context) {
    // try {
        // let post = await getApiPostById(getUser().localId, context.params._id)
        // if (post._ownerId == getUser().localId) {
            // Object.assign(context, getUser(), post)
            // await preloadPartials(context)

            // this.partial('/templates/edit.hbs')
        // }

    // } catch (error) {
        // showError('Error')
    // }

// }

// export async function editPost(context) {
    // let postId = context.params._id;
    // let { title, category, content } = context.params
    // try {
        // if (getUser()) {
            // if (title == '' ||
                // category == '' ||
                // content == '') {
                // throw new Error('All fields are required')
            // }
            // let editedpost = Object.assign({}, context.params)

            // let response = await editApiPostById(getUser().localId, postId, editedpost);
            // showInfo('The post is edited')
            // context.redirect(`/home`)
        // }

    // } catch (error) {
        // showError('The post is NOT edited')
    // }


// }




// export async function deletePost(context) {
    // let postId = context.params._id;
    // try {
        // if (getUser()) {
            // let post = await getApiPostById(getUser().localId, postId)
            // if (post._ownerId == getUser().localId) {
                // let response = await deletePostById(getUser().localId, postId)
                // showInfo('The post is deleted')
                // this.redirect(`/home`)
            // }
        // }


    // } catch (error) {
        // showError('The post is NOT delited')
    // }

// }

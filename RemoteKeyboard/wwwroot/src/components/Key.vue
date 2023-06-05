<script setup lang="ts">

import {ref} from "vue";

const props = defineProps({
    uri: String,
    idx: Number
})

const ws_press   = new WebSocket(`${props.uri}/0/${props.idx}`);
const ws_release = new WebSocket(`${props.uri}/1/${props.idx}`);

let lat = ref(0)
let all = ref(0)

const div = ref(null as unknown as HTMLDivElement)


function touch_start() {
    ws_press.send('')
    div.value.style.background = 'red'
}


function touch_end() {
    ws_release.send('');
    div.value.style.background = ''
}


</script>

<template>
    <div @touchstart="touch_start" @touchend="touch_end" v-bind="$attrs">
        <div ref="div" class="border-2 bg-green-200 border-green-100 h-full"></div>
    </div>
</template>
<script setup lang="ts">
import './style.css'
import {ref} from "vue";
import {range} from "./utils";
import Key from "./components/Key.vue";


const keys = 4
const uri = `ws://${location.hostname}:${location.port}/ws`;
const wrap = ref(null as unknown as HTMLDivElement)

</script>

<template>
    <div class="relative h-full bg-white">
        <div class="wrap" ref="wrap">
            <template v-for="i in range(keys)" :key="i">
                <Key :uri="uri" :idx="i"/>
            </template>
        </div>

        <div
            class="absolute inset-0 flex justify-center text-center items-center bg-black bg-opacity-50 text-4xl text-cyan-50 capitalize">
            <div class="bg-green-600 p-5 rounded-l-2xl hover:bg-green-700">
                settings
                
            </div>
            <div @click="wrap.requestFullscreen()" class="bg-violet-700 p-5 rounded-r-2xl hover:bg-violet-900">
                go play
            </div>
        </div>
    </div>
</template>

<style scoped>
.wrap {
    @apply flex bg-white items-center justify-center h-full;
}

.wrap > * {
    @apply grow h-full
}
</style>
